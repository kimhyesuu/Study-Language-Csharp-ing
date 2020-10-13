using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{

 
   
    // 4. 클래스의 인스턴스를 생성하고 이 객체의 이벤트에 3에서 작성한 이벤트 핸들러를 등록합니다.
    // 5. 이벤트가 발생하면서 이벤트 핸들러가 호출

    //문제 3의 배수에 짝을 치게 만들기

    // 1. 대리자를 선언합니다. 이 대리자는 클래스 밖에 선언해도 되고 안에 선언해도 됩니다.
    delegate void EventHandler(string Message);

    class Notifier
    {
        // 2. 클래스 내에 1에서 선언한 대리자의 인스턴스를 event 한정자로 수식해서 선언
        public event EventHandler SomthingHappened;

        public void SomthingHappening(int value)
        {
            if (value % 3 == 0 && value > 0)
                SomthingHappened(String.Format("{0} : 짝",value));
        }
    }

    class Program
    {
        // 3. 이벤트 핸들러를 작성합니다. 이벤트 핸들러는 1에서 선언한 대리자와 일치하는 메소드면 됩니다.
        public static void MyHandler(string Message)
        {
            Console.WriteLine(Message);
        }

        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.SomthingHappened += new EventHandler(MyHandler);

            for (int i = 0; i < 31; i++)
                notifier.SomthingHappening(i);

            Console.ReadKey();
        }
    }
}
