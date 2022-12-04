using Desktop_Diary.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

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