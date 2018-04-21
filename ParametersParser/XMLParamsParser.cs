using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

namespace ParametersParser
{    
    /// <summary>
    /// Класс для работы с XML сообщеними модели
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class ModelMessage
    {
        #region Properties

        private string header_T;
        /// <summary>
        /// Параметр заголовка сообщения (Get, Set)
        /// </summary>
        public string Header_T
        {
            get { return header_T; }
            set { header_T = value; }
        }

        private string header_S;
        /// <summary>
        /// Параметр заголовка сообщения (Get, Set)
        /// </summary>
        public string Header_S
        {
            get { return header_S; }
            set { header_S = value; }
        }

        private HybridDictionary parameters;
        /// <summary>
        /// Коллекция параметров сообщения (Get, Set)
        /// </summary>
        public HybridDictionary Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        /// <summary>
        /// Кол-во параметров в сообщении (Get)
        /// </summary>
        public int ParamsCount
        {
            get { return parameters.Count; }
        }

        private string message;
        
        #endregion

        #region ctors

        public ModelMessage()
        {
            message = String.Empty;
            header_T = String.Empty;
            header_S = String.Empty;
            parameters = new HybridDictionary();
        }

        public ModelMessage(string ModelMessaqe)
        {
            this.message = ModelMessaqe;

            parameters = new HybridDictionary();

            ParseString();

        } 

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Получение значения пар-ра по ключу
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        public object GetParameter(object ParameterName)
        {
            object Result = null;

            if (parameters.Contains(ParameterName))
            {
                Result = parameters[ParameterName];
            }

            return Result;
        }

        /// <summary>
        /// Добавление пар-ра в коллекцию
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="ParameterValue"></param>
        public void AddParameter(object ParameterName, object ParameterValue)
        {
            if (!parameters.Contains(ParameterName))
            {
                parameters.Add(ParameterName, ParameterValue);
            }

        }

        /// <summary>
        /// Удаление пра-ра из коллекции
        /// </summary>
        /// <param name="ParameterName"></param>
        public void RemoveParameter(object ParameterName)
        {
            if (parameters.Contains(ParameterName))
            {
                parameters.Remove(ParameterName);
            }
        }

        /// <summary>
        /// Построение XML сообщения
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder Result = new StringBuilder();

            Result.Append("<HD><T>" + header_T + "</T><S>" + header_S + "</S></HD><P>");

            foreach (object var in parameters.Keys)
            {
                Result.Append("<PN>" + var.ToString() + "</PN><V>" + parameters[var].ToString() + "</V>");
            }

            Result.Append("</P>");

            message = Result.ToString();

            return message;
        } 

        #endregion

        #region Private Methods

        private void ParseString()
        {

            #region Header
            if (message.Contains("<T>"))
            {
                header_T = message.Substring(message.IndexOf("<T>") + 3, message.IndexOf("</T>") - 3 - message.IndexOf("<T>"));
            }

            if (message.Contains("<S>"))
            {
                header_S = message.Substring(message.IndexOf("<S>") + 3, message.IndexOf("</S>") - 3 - message.IndexOf("<S>"));
            }
            #endregion


            #region Parameters
            if (message.Contains("<P>"))
            {
                string strParams = message.Substring(message.IndexOf("<P>"));

                int Index = 0;

                while (strParams.IndexOf("<PN>", Index) != -1)
                {

                    string ParamName = String.Empty;
                    string ParamValue = String.Empty;

                    ParamName = strParams.Substring(strParams.IndexOf("<PN>", Index) + 4, strParams.IndexOf("</PN>", Index) - 4 - strParams.IndexOf("<PN>", 0));
                    ParamValue = strParams.Substring(strParams.IndexOf("<V>", Index) + 3, strParams.IndexOf("</V>", Index) - 3 - strParams.IndexOf("<V>", 0));

                    strParams = strParams.Substring(strParams.IndexOf("</V>") + 4);

                    if (!parameters.Contains(ParamName))
                    {
                        parameters.Add(ParamName, ParamValue);
                    }

                }

            }
            #endregion

        }
        
        #endregion
    }
}
