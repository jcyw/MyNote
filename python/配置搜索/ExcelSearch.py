import os
import openpyxl
from concurrent.futures import ProcessPoolExecutor
from functools import lru_cache
import time
import warnings
import threading
from functools import cache


# 屏蔽UserWarning类型的警告信息
warnings.filterwarnings("ignore", category=UserWarning)
# @cache
def load_excel_data(file_path, gl_search_string):
    # 打开workbook
    wb = openpyxl.load_workbook(filename=file_path, data_only=True)
    # 遍历所有worksheet
    for sheet in wb.worksheets:
        # 遍历每个cell
        for row in sheet.iter_rows():
            for cell in row:
                # 获取单元格的值（如果单元格包含公式，则返回计算结果）
                value = str(cell.value)
                # 如果找到目标字符串，输出表名、工作表名、行和列
                if (value == gl_search_string):
                    print(value + " " * 10)
                    print(f"文件名：{file_path}\n工作表名：{sheet.title}\n单元格位置：({cell.row}, {cell.column})\n")

def search_excel_file(file_path,gl_search_string):
    try:
        load_excel_data(file_path, gl_search_string)

    except Exception as e:
        print(f"搜索文件 {file_path} 时发生异常：{e}")


def search_folder(path, gl_search_string):
    # load_excel_data.cache_clear()
    # 使用锁来确保线程安全
    lock = threading.Lock()

    with ProcessPoolExecutor() as executor:
        for foldername, subfolders, filenames in os.walk(path):
            for filename in filenames:
                file_path = os.path.join(foldername, filename)
                if file_path.endswith('.xlsx') and not file_path.startswith('~$'):
                    executor.submit(search_excel_file, file_path, gl_search_string)

    # 停止输出省略号
    global is_running
    with lock:
        is_running = False


if __name__ == '__main__':
    # 初始化is_running变量和搜索结果列表
    global is_running
    is_running = True

    # 输出搜索字符串和路径
    gl_search_string= input("请输入要搜索的字符串：")
    with open('./path.txt', 'r', encoding='utf-8') as f:
        path = f.read()
    path = path.replace('\\', '/')
    f.close()
    print(f"正在搜索文件夹 {path} 中包含 '{gl_search_string}' 的Excel文件，请稍等...\n")
    if path.endswith('.xlsx'):
        if not path.startswith('~$'):
            search_excel_file(path, gl_search_string)
    else:
        # 在新线程中搜索Excel文件夹
        thread = threading.Thread(target=search_folder, args=(path,gl_search_string))
        # search_folder(path, gl_search_string)
        thread.start()

        # 等待搜索完成 输出省略号
        mindex = 0
        while is_running:
            if mindex >= 7:
                mindex = 0
                print(" " * 15, end="\r")  # 清空控制台
            mindex = mindex + 1
            print("Searching" + "." * mindex + " " * 10, end="\r")
            time.sleep(0.5)  # 等待0.5秒

        print("over!!!!")
