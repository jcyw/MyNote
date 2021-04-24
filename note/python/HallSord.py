def hill(data):  # 自定义希尔排序函数
    n = len(data)  # 获取数据长度
    step = n // 2  # 让步长从大变小，最后一步必须是1，获取gap的偏移值
    while step >= 1:  # 只要gap在我们的合理范围内，就一直分组下去
        # 按照步长把数据分两半，从步长的位置遍历后面所有的数据,指定j下标的取值范围
        for j in range(step, n):
            while j - step >= 0:  # 拿当前位置的数据，跟当前位置-gap位置的数据进行比较
                if data[j] < data[j - step]:  # 组内大小元素进行替换操作
                    data[j], data[j - step] = data[j - step], data[j]
                    j -= step  # 更新迁移元素的下标值为最新值
                else:  # 否则的话，不进行替换
                    break
        step //= 2  # 每执行完毕一次分组内的插入排序，对gap进行/2细分


data = [60, 82, 17, 35, 52, 73, 54, 9]  # 定义列表并初始化
print("原始数据：")
print(data)  # 输出原数据
print("---------------------------------")
hill(data)  # 调用自定义希尔排序函数
print("排序之后的数据：")
print(data)  # 输出排序之后数据
print("---------------------------------")