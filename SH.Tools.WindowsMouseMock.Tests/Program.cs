// See https://aka.ms/new-console-template for more information
using SH.Tools.WindowsMouseMock;
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
MouseMethod.SimulateMouseWheel(MouseMethod.MouseWheelDirection.Down, 100);
Console.ReadKey();
