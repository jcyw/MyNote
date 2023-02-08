# openpyxl是一个非标准库，因此需要自行安装，安装过程并不困难，Windows/Mac用户均可以在命令行(CMD)/终端(Terminal)中使用pip安装

# pip install openpyxl

# 前置知识
# 单元格Cell
# 列column
# 行row
# 表sheet

# 1.载入Excel       注意load_workbook只能打开已经存在的Excel，不能创建新的工作簿
from openpyxl import load_workbook
workbook = load_workbook('Excel学习.xlsx') 
print(workbook.sheetnames)
# 2.根据名称获取工作表
# 如果只有一张工作表也可以用：

# sheet = workbook.active
sheet = workbook["Sheet1"]

# 3.获取表格内容所在的范围
print(sheet.dimensions)

# 4.获取某个单元格的具体内容
# 这边提供两种方法，注意都需要以cell.value形式输出具体值
# 指定坐标
cell = sheet['A1']
print(cell.value)
# 指定行列
cell = sheet.cell(row = 3 , column = 2)
print(cell.value)

# 5.获取某个单元格的行、列、坐标
print(cell.row, cell.column , cell.coordinate)

# 6.获取多个格子的值
# 指定坐标范围
cells = sheet['A1:B5']
# 指定列的值
cells = sheet['A']
cells = sheet['A:C']
# 指定行的值
cells = sheet[5]
cells = sheet[5:6]
# 这里也有一个细节，Excel中每一列由字母确定，是字符型；每一行由一个数字确定，是整型。
# 当然，上面的三种方法都是获取一堆表格，现在要输出每一个表格的值就需要遍历：
# for cellchild in cells:
#     print(cellchild.value)