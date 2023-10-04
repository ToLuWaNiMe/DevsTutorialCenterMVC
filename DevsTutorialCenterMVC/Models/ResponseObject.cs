namespace DevsTutorialCenterMVC.Models
{
   
        public class ResponseObject<T>
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public string Error { get; set; }
        }
    
}
