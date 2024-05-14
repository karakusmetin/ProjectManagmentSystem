namespace PMS_WebUI.ResultMessages
{
    public static class Messages
    {
        public static class Project
        {
            public static string Add(string projectTitle)
            {
                return $"{projectTitle} başlıklı proje başarı ile eklendi";
            }
            public static string Update(string projectTitle)
            {
                return $"{projectTitle} başlıklı proje başarı ile düzenlendi";
            }
            public static string Delete(string projectTitle)
            {
                return $"{projectTitle} başlıklı proje başarı ile silindi";
            }
        }

        public static class Task
        {
            public static string Add(string taskName)
            {
                return $"{taskName} başlıklı görev başarı ile eklendi";
            }
            public static string Update(string taskName)
            {
                return $"{taskName} başlıklı task başarı ile düzenlendi";
            }
            public static string Delete(string taskName)
            {
                return $"{taskName} başlıklı task başarı ile silindi";
            }
        }
    }
}
