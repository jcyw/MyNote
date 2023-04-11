import os
import pandas as pd
from concurrent.futures import ThreadPoolExecutor
import time
import warnings


# 屏蔽UserWarning类型的警告信息
warnings.filterwarnings("ignore", category=UserWarning)

def search_excel_file(file_path, gl_search_string):
    try:
        # 读取Excel文件
        df = pd.read_excel(file_path, engine='openpyxl', sheet_name=None)

        for sheet_name, sheet in df.items():
            # 在每个worksheet中查找目标字符串
            if gl_search_string in str(sheet.values):
                print(f"在文件 {file_path} 的表格 '{sheet_name}' 中找到匹配项：\n")
                # 遍历每个cell
                for row_index, row in sheet.iterrows():
                    for col_index, value in row.iteritems():
                        # 如果找到目标字符串，输出行列和值
                        if (gl_search_string == str(value)):
                            print(f"行号：{row_index + 1}\t列名：{col_index}\t值：{value}\n")

    except Exception as e:
        print(f"搜索文件 {file_path} 时发生异常：{e}")


def search_folder(path, gl_search_string):
    with ThreadPoolExecutor() as executor:
        for foldername, subfolders, filenames in os.walk(path):
            for filename in filenames:
                file_path = os.path.join(foldername, filename)
                if file_path.endswith('.xlsx') and not file_path.startswith('~$'):
                    executor.submit(search_excel_file, file_path, gl_search_string)


if __name__ == '__main__':
    # 输出搜索字符串和路径
    gl_search_string= input("请输入要搜索的字符串：")
    with open('./path.txt', 'r', encoding='utf-8') as f:
        path = f.read()
    path = path.replace('\\', '/')
    f.close()
    print(f"正在搜索文件夹 {path} 中包含 '{gl_search_string}' 的Excel文件，请稍等...\n")

    # 在新线程中搜索Excel文件夹
    thread = ThreadPoolExecutor(max_workers=1).submit(search_folder, path, gl_search_string)

    # 等待搜索完成 输出省略号
    mindex = 0
    while not thread.done():
        if mindex >= 7:
            mindex = 0
            print(" " * 15, end="\r")  # 清空控制台
        mindex = mindex + 1
        print("Searching" + "." * mindex + " " * 10, end="\r")
        time.sleep(0.5)  # 等待0.5秒

    # 停止输出省略号
    print(" " * 15, end="\r")

    print("搜索完成！")
