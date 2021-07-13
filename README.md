# BrowserTimer

```Form1.cs``` 파일을 열어보시면

```cs
namespace BrowserTimer
{
    public partial class Form1 : Form
    {
        public static bool isWorking;      // Checking Button is ON or OFF
        public static int TIME_INTERVAL = 10000;    // 밀리초 기준입니다. 10000밀리초 = 10초 ㅇㅋ?
        public static string REDIRECT_URL = "https://www.naver.com";
```

이 부분이 있을거에요. ```TIME_INTERVAL``` 변수와 ```REDIRECT_URL``` 변수를 수정해주시면 원하시는 목적을 달성할 수 있을거에요. 화이팅.
