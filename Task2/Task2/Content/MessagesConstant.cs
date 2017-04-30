namespace Task2.Content
{
    public static partial class Messages
    {
        public static class MessagesConstant
        {

            public static readonly MessageString Number = new MessageString("Число:");
            public static readonly MessageString Scatter = new MessageString("Разброс коллекции от введенного числа:");
            public static readonly MessageString SizeOfCollection = new MessageString("Размер коллекции:");
            public static readonly MessageString CreationCollection = new MessageString("Создание коллекции.");
            public static readonly MessageString ConvertToHashSet = new MessageString("Конвертация в хеш таблицу");
            public static readonly MessageString FindResult = new MessageString("Нахождение пар результирующего множества.");

            public static readonly MessageString ThePairOfResults = new MessageString("Результирующие пары:");
            public static readonly MessageString NoResult = new MessageString("Результирующие пары отсутствуют.");
            
            public static readonly MessageString NumberException = new MessageString("Введено ошибочное числовое значение: {0}");
            
        }
    }
}
