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
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENT_LEFTDOWN = 0x2;
        private const int MOUSEEVENT_LEFTUP = 0x4;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;
        private const int MOUSEEVENT_WHEEL = 0x0800;
        /// <summary>
        /// 鼠标移动到某点
        /// </summary>
        /// <param name="pt"></param>
        public static void MouseMoveToPoint(int x, int y)
        {
            _ = SetCursorPos(x, y);
        }

        /// <summary>
        /// 鼠标点击某点
        /// </summary>
        /// <param name="pt"></param>
        public static void MouseRightClick(int x, int y)
        {
            MouseMoveToPoint(x,y);
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

        public enum MouseWheelDirection
        {
            Up,
            Down
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
    }
}