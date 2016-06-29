using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pt_parte_1_2
{
    class DictionaryNode
    {
        // <summary>
        /// Word.
        /// </summary>
        string _word;

        /// <summary>
        /// Dict.
        /// </summary>
        Dictionary<char, DictionaryNode> _dict;

        /// <summary>
        /// Add.
        /// </summary>
        public DictionaryNode Add(char value)
        {
            // Handle null field.
            if (this._dict == null)
            {
                this._dict = new Dictionary<char, DictionaryNode>();
            }
            // Lookup and return if possible.
            DictionaryNode result;
            if (this._dict.TryGetValue(value, out result))
            {
                return result;
            }
            // Store.
            result = new DictionaryNode();
            this._dict[value] = result;
            return result;
        }

        /// <summary>
        /// Get.
        /// </summary>
        public DictionaryNode Get(char value)
        {
            if (this._dict == null)
            {
                return null;
            }
            // Lookup.
            DictionaryNode result;
            if (this._dict.TryGetValue(value, out result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Set word.
        /// </summary>
        public void SetWord(string word)
        {
            this._word = word;
        }

        /// <summary>
        /// Get word.
        /// </summary>
        public string GetWord()
        {
            return this._word;
        }
    }
}
