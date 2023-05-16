# SH.Tools 工具类
 
 1. SH.Tools.WindowsMouseMock 鼠标模拟类
 ~~~
 // See https://aka.ms/new-console-template for more information
using SH.Tools.WindowsMouseMock;
using System.Text;

// 模拟键盘按下
MouseMethod.KeyClick('A');
//模拟点击
MouseMethod.MouseClick(100, 100);
Task.Delay(2000).Wait();
// 鼠标移动
MouseMethod.MouseMoveToPoint(200, 200);
Task.Delay(2000).Wait();
// 鼠标右键
MouseMethod.MouseRightClick(400, 200);
Task.Delay(2000).Wait();
MouseMethod.MouseClick(400, 200);
Task.Delay(2000).Wait();
MouseMethod.SimulateMouseWheel(MouseWheelDirection.Down, 100);

Task.Delay(2000).Wait();
MouseMethod.CTRLSimulateMouseWheel(MouseWheelDirection.Down, 100);
Task.Delay(2000).Wait();
MouseMethod.CTRLSimulateMouseWheel(MouseWheelDirection.Down, -100);

Console.ReadKey();

 ~~~
 
 
