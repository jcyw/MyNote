# 现有一台饮水机，可以制备冷水、温水和热水。每秒钟，可以装满 2 杯 不同 类型的水或者 1 杯任意类型的水。
# 给你一个下标从 0 开始、长度为 3 的整数数组 amount ，其中 amount[0]、amount[1] 和 amount[2] 分别表示需要装满冷水、温水和热水的杯子数量。返回装满所有杯子所需的 最少 秒数。

# 示例 1：

# 输入：amount = [1,4,2]
# 输出：4
# 解释：下面给出一种方案：
# 第 1 秒：装满一杯冷水和一杯温水。
# 第 2 秒：装满一杯温水和一杯热水。
# 第 3 秒：装满一杯温水和一杯热水。
# 第 4 秒：装满一杯温水。
# 可以证明最少需要 4 秒才能装满所有杯子。
# 示例 2：

# 输入：amount = [5,4,4]
# 输出：7
# 解释：下面给出一种方案：
# 第 1 秒：装满一杯冷水和一杯热水。
# 第 2 秒：装满一杯冷水和一杯温水。
# 第 3 秒：装满一杯冷水和一杯温水。
# 第 4 秒：装满一杯温水和一杯热水。
# 第 5 秒：装满一杯冷水和一杯热水。
# 第 6 秒：装满一杯冷水和一杯温水。
# 第 7 秒：装满一杯热水。
# 示例 3：

# 输入：amount = [5,0,0]
# 输出：5
# 解释：每秒装满一杯冷水。

# 来源：力扣（LjeetCode）
# 链接：https://leetcode.cn/problems/minimum-amount-of-time-to-fill-cups
# 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
arr = [1,4,2]
def GetOpTime():
    times = 0
    while True:
        index1 , index2 = GetIndex()
        print(index1 , index2)
        if index1 + index2 == -2:
            print('break')
            break
        times = times + 1
        if index1 > -1:
            arr[index1] = arr[index1] - 1
        if index2 > -1:
            arr[index2] = arr[index2] - 1
    print(times)

# 获取至多两个数的index
def GetIndex():
    tempIndex1 = -1
    tempIndex2 = -1
    if arr[0] > 0:
        tempIndex1 = 0
    if arr[1] > 0:
        tempIndex2 = 1
    if arr[2] > 0:
        if arr[2] > arr[0]:
            tempIndex1 = 2
        elif arr[2] > arr[1]:
            tempIndex2 = 2
        else:
            pass
    return tempIndex1, tempIndex2 

GetOpTime()