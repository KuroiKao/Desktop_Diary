using Desktop_Diary.BaseContext;

namespace Desktop_Diary
{
    public class SingletonBase
    {
        private static DiaryBaseContext? instance;
        public static DiaryBaseContext GetInstance()
        {
            if (instance == null)
                instance = new DiaryBaseContext();
            return instance;
        }
    }
}