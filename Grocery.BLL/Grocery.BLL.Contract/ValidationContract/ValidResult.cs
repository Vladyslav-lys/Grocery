using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public class ValidResult
    {
        private string error = "";
        private bool isValidated;

        public ValidResult()
        {
            isValidated = true;
        }

        //Выводит ошибки при заданных условиях валидации
        public ValidResult(bool isValidated, string errorMessage)
        {
            this.isValidated = isValidated;

            if (isValidated && errorMessage.Length > 0)
            {
                this.error = "Validation result is succsessful but has error message!";
                throw new Exception(this.error);
            }

            if (!isValidated && errorMessage.Length == 0)
            {
                this.error = "Validation result is failed but has no error message!";
                throw new Exception(this.error);
            }

            if (errorMessage.Length > 0)
            {
                this.error = errorMessage;
            }
        }

        //Перечисление сообщений об ошибке и возвращение строки с этими ошибками
        public string GetError()
        {
            return this.error;
        }
    }
}
