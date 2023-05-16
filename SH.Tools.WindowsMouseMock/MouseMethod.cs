using System.Runtime.InteropServices;

namespace SH.Tools.WindowsMouseMock
{
    /// <summary>
    /// 鼠标方法
    /// </summary>
    public class MouseMethod
    {

        /// <summary>
        /// 引用 user32.dll（windows api）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

   
        private const int MOUSEEVENT_LEFTDOWN = 0x2;
        private const int MOUSEEVENT_LEFTUP = 0x4;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;
        private const int MOUSEEVENT_WHEEL = 0x0800;
        private const int CTRL = 0x11;
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;
        /// <summary>
        /// 鼠标移动到某点
        /// </summary>
        /// <param name="pt"></param>
        public static void MouseMoveToPoint(int x, int y)
        {
            _ = SetCursorPos(x, y);
        }

        /// <summary>
        /// 获取当前光标的位置
        /// </summary>
        /// <returns></returns>
        public static POINT? CursorPos()
        {
            POINT  oINT = new POINT();
            if (!GetCursorPos(out oINT))
            {
                return null;
            }
            return oINT;
        }
        /// <summary>
        /// 鼠标点击某点
        /// </summary>
        /// <param name="pt"></param>
        public static void MouseRightClick(int x, int y)
        {
            MouseMoveToPoint(x, y);
            mouse_event(MOUSEEVENT_RIGHTDOWN | MOUSEEVENT_RIGHTUP, x, y, 0, 0);
        }

        /// <summary>
        /// 鼠标点击右键某点
        /// </summary>
        /// <param name="pt"></param>
        public static void MouseClick(int x, int y)
        {
            MouseMoveToPoint(x, y);
            mouse_event(MOUSEEVENT_LEFTDOWN | MOUSEEVENT_LEFTUP, x, y, 0, 0);
        }

        /// <summary>
        /// 模拟滚轮
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="delta">距离</param>
        public static void SimulateMouseWheel(MouseWheelDirection direction, int delta)
        {
            int flags = MOUSEEVENT_WHEEL;
            if (direction == MouseWheelDirection.Down)
                delta = -delta; // 向下滚动时 delta 是负数
            mouse_event(flags, 0, 0, delta, 0);
        }
        /// <summary>
        /// 模拟 CTRL 加滚轮
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="delta"></param>
        public static void CTRLSimulateMouseWheel(MouseWheelDirection direction, int delta)
        {
            keybd_event(CTRL, 0, KEYEVENTF_EXTENDEDKEY, 0);
            int flags = MOUSEEVENT_WHEEL;
            if (direction == MouseWheelDirection.Down)
                delta = -delta; // 向下滚动时 delta 是负数
            mouse_event(flags, 0, 0, delta, 0);
            keybd_event(0x11, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        /// <summary>
        ///  模拟点击键盘
        /// </summary>
        /// <param name="key"></param>
        public static void KeyClick(char key)
        {
            var v =byte.Parse(((int)key).ToString("X2"));
            // 模拟按下A键
            keybd_event(v, 0, KEYEVENTF_EXTENDEDKEY, 0);
            // 模拟释放A键
            keybd_event(v, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
}