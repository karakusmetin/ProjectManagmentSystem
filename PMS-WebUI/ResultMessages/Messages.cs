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
            public static string UndoDelete(string projectTitle)
            {
                return $"{projectTitle} başlıklı proje başarı ile geri alındı";
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
            public static string UndoDelete(string taskName)
            {
                return $"{taskName} başlıklı task başarı ile geri alındı";
            }
        }
        public static class User
        {
            public static string Add(string userEmail)
            {
                return $"{userEmail} email adresli kullanıcı başarı ile eklendi";
            }
            public static string Update(string userEmail)
            {
                return $"{userEmail} email adresli kullanıcı başarı ile düzenlendi";
            }
            public static string Delete(string userEmail)
            {
                return $"{userEmail} email adresli kullanıcı başarı ile silindi";
            }
        }

        public static class ProjectUser
        {
            public static string Add()
            {
                return "Projeye kullanıcı başarı ile eklendi";
            }
            public static string Update()
            {
                return "Proje kullanıcı ilişkisi başarı ile düzenlendi";
            }
            public static string Delete()
            {
                return "Proje kullanıcı ilişkisiı başarı ile silindi";
            }
            public static string Error()
            {
                return "Zaten Proje İçerisinde Kullanıcı Mevcut";
            }
        }
    }
}
