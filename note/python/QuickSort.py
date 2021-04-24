def quick(data, start, end):  # 定义快速排序法函数
    if start > end:  # 如果开始值大于结束值
        return  # 直接退出程序
    i, j = start, end
    result = data[start]  # 取虚拟中间值
    while True:  # 循环
        while j > i and data[j] >= result:  # 从右向左找，找到的数比虚拟中间值小就停止循环
            j = j - 1  # 从右向左找，位置每次-1
        while i < j and data[i] <= result:  # 从左向右找，找到的数比虚拟中间值大就停止循环
            i += 1  # 从左向右找，位置每次+1
        if i < j:  # i和j都停止，找到对应的位置，判断i<j
            data[i], data[j] = data[j], data[i]  # 交换位置i和j对应的数值
        elif i >= j:  # 判断i>=j
            # 交换虚拟中间值和j位置上的数，此时虚拟中间值变成真正中间值
            data[start], data[j] = data[j], data[start]
            break  # 完成第一次排序，此时以中间值分左右两侧
    quick(data, start, i - 1)  # 调用快速排序函数，再快速排序左半边数据
    quick(data, i + 1, end)  # 调用快速排序函数，再快速排序右半边数据


data = [6, 1, 2, 7, 9, 3, 4, 5, 10, 8]  # 定义列表并初始化
print("原始数据为：")
print(data)  # 输出原始数据
print("--------------------------------")
quick(data, 0, (len(data) - 1))  # 调用快速排序，数据从位置0开始，到数据长度-1为止
print("排序之后的数据为：")
print(data)  # 输出排序后数据
print("--------------------------------")