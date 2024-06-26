import tkinter as tk
from datetime import datetime
from pyToGPT import askGPT
import asyncio

root = tk.Tk()

# 创建展示区域的Frame并加入Scrollbar
canvas_frame = tk.Frame(root)
scrollbar = tk.Scrollbar(canvas_frame, orient=tk.VERTICAL)
scrollbar.pack(side=tk.RIGHT, fill=tk.Y)

# 创建Canvas并添加到展示区域的Frame中
canvas = tk.Canvas(canvas_frame, yscrollcommand=scrollbar.set)
canvas.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
scrollbar.config(command=canvas.yview)

# 添加滚动功能
def on_canvas_configure(event):
    canvas.configure(scrollregion=canvas.bbox("all"))
canvas.bind('<Configure>', on_canvas_configure)

# 创建输入框并放置于顶部
input_box = tk.Entry(root)
input_box.insert(0, "请输入文本")
input_box.bind("<FocusIn>", lambda event: input_box.delete(0, "end"))  # 绑定焦点事件，清空文本
input_box.pack(side=tk.TOP, fill=tk.X)

# 创建展示文本的Label，并添加到Canvas中
text_label = tk.Label(canvas, text="", wraplength=500)
canvas.create_window((0, 0), anchor="nw", window=text_label)

# 创建记录列表
record_list = []

# 创建按钮，绑定展示文本的函数
async def show_text():
    # 获取当前时间
    current_time = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    try:

        # 获取输入文本
        text = await asyncio.wait_for(askGPT(input_box.get()), timeout=10)
    except asyncio.TimeoutError:
        text = "请求超时！请重试"
    
    # 构建记录字符串
    record = f"{current_time}: {text}"
    
    # 将记录添加到列表中
    record_list.append(record)
    
    # 更新展示区域中的文本
    text_label.config(text="\n".join(record_list))

search_button = tk.Button(root, text="搜索", command=lambda: asyncio.run(show_text()))
search_button.pack(side=tk.BOTTOM)

# 将展示区域的Frame添加到主窗口中
canvas_frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)

# 运行主循环
root.mainloop()
