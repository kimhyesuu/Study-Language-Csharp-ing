using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 중첩 클래스는 클래스 안에 선언되어 있는 클래스를 의미 

   // 사용 목적
   // 1. 클래스 외부에 공개하고 싶지 않은 형식을 만들고자 할 때
   // 2. 현재의 클래스의 일부분처럼 표현할 수 있는 클래스를 만들고자 할 떄
namespace NestedClass
{
   class Configuration
   {
      // 인스턴스 생성시 같이 생성
      List<ItemValue> listConfig = new List<ItemValue>();

      public void SetConfig(string item, string value)
      {
         //list에 넣을 ItemValue 인스턴스생성
         ItemValue itemValue = new ItemValue();
         //적합한지 확인하는 부분
         itemValue.SetValue(this,item,value);
     
      }

      public string GetConfig(string item)
      {
         string Ex = "";
         //리스트에서 값을 찾아본다.
         foreach (ItemValue itemValue in listConfig)
         {
            // item 파라미터를 받았을 때 Getitem에 있는 지 확인 그 후 value 값만 보내는 형식 
            if (itemValue.GetItem() == item)
               return Ex = itemValue.GetValue();
         }

         // 없으면 이렇게 선택
         return Ex;
      }

      private class ItemValue
      {
         private string item;
         private string value;

         //결과값만 받는다.
         public string GetItem() { return item; }
         public string GetValue() { return value; }


         public void SetValue(Configuration Config, string item, string value)
         {            
            this.item = item;
            this.value = value;

            bool found = false;

            //똑같은 값이 있는 지 확인 체크
            for (int index = 0; index < Config.listConfig.Count; index++)
            {
               if (Config.listConfig[index].item == item)
               {
                  Config.listConfig[index] = this;
                  found = true;
                  break;
               }         
            }

            //없다면 추가
            if (found == false)
            {
               Config.listConfig.Add(this);
            }
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Configuration config = new Configuration();
         config.SetConfig("Version","V 5.0");
         config.SetConfig("Size", "655,324 KB");
         
         Console.WriteLine(config.GetConfig("Version"));
         Console.WriteLine(config.GetConfig("Size"));

         config.SetConfig("Version","V 5.0.1");
         Console.WriteLine(config.GetConfig("Version"));
      }
   }
}
