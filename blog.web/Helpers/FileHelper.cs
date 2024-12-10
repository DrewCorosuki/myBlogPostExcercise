namespace blog.web.Helpers
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile file, string destination)
        {
            try
            {
                var fileExt = Path.GetExtension(file.FileName);
                var fileName = DateTime.Now.Ticks.ToString() + fileExt;
                var filePath = Path.Combine(destination, fileName);
                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileSrteam);
                }
                return fileName;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
