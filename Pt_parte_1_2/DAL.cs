using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class DAL
    {
        private SqlConnection _SqlConn;
        private SqlCommand _SqlCommand;
        private SqlDataReader _SqlReader;



        public DAL()
        {

            _SqlConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Tomas1207Portable\\Documents\\Ezedesktop.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private void abrirLigacao()
        {
            try
            {
                _SqlConn.Open();
            }
            catch (Exception e)
            {

            }
        }

        private void fecharLigacao()
        {
            try
            {
                _SqlConn.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void associarComando(String sqlCmd)
        {
            _SqlCommand = new SqlCommand(sqlCmd, _SqlConn);
        }

        public DataTable executarStoredProcReader(String sqlCmd, SqlParameter[] sqlParams)
        {
            DataTable returnTable = new DataTable("returnTable");

            associarComando(sqlCmd);

            _SqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlParams != null)
                _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                _SqlReader = _SqlCommand.ExecuteReader();

                returnTable.Load(_SqlReader);

                _SqlReader.Close();
            }

            fecharLigacao();

            return returnTable;
        }

        //Stored Procedure sem parâmetros
        public DataTable executarStoredProcReader(String sqlCmd)
        {
            return this.executarStoredProcReader(sqlCmd, null);
        }

        public int executarStoredProcNonQuery(String sqlCmd, SqlParameter[] sqlParams)
        {
            int retorno = -1;

            associarComando(sqlCmd);

            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                retorno = _SqlCommand.ExecuteNonQuery();
            }

            fecharLigacao();

            return retorno;
        }

        public object executarStoredProcScalar(String sqlCmd, SqlParameter[] sqlParams)
        {
            object resultado = null;
            associarComando(sqlCmd);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                resultado = _SqlCommand.ExecuteScalar();
            }

            fecharLigacao();
            _SqlCommand.Parameters.Clear();
            return resultado;
        }

        public DataTable executarReader(String sqlCmd, SqlParameter[] sqlParams)
        {
            DataTable returnTable = new DataTable("returnTable");

            associarComando(sqlCmd);

            _SqlCommand.CommandType = CommandType.Text;

            if (sqlParams != null)
                _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                _SqlReader = _SqlCommand.ExecuteReader();

                returnTable.Load(_SqlReader);

                _SqlReader.Close();
            }

            fecharLigacao();
            _SqlCommand.Parameters.Clear();
            return returnTable;
        }

        public int executarNonQuery(String sqlCmd, SqlParameter[] sqlParams)
        {
            int retorno = -1;

            associarComando(sqlCmd);

            _SqlCommand.CommandType = CommandType.Text;
            _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                _SqlCommand.ExecuteNonQuery();
            }

            fecharLigacao();
            _SqlCommand.Parameters.Clear();
            return retorno;
        }

        public object executarScalar(String sqlCmd, SqlParameter[] sqlParams)
        {
            object resultado = null;
            associarComando(sqlCmd);
            _SqlCommand.CommandType = CommandType.Text;
            _SqlCommand.Parameters.AddRange(sqlParams);

            abrirLigacao();

            if (_SqlConn.State == ConnectionState.Open)
            {
                resultado = _SqlCommand.ExecuteScalar();
            }

            fecharLigacao();
            _SqlCommand.Parameters.Clear();
            return resultado;
        }
    }
}