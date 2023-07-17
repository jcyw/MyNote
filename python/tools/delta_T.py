# 计算两个时间差
from datetime import datetime

# 定义两个时间字符串
time_str1 = "2023-07-17 16:31:00"
time_str2 = "2023-07-18 08:30:00"

# 将时间字符串转换为 datetime 对象
time1 = datetime.strptime(time_str1, "%Y-%m-%d %H:%M:%S")
time2 = datetime.strptime(time_str2, "%Y-%m-%d %H:%M:%S")

# 计算时间差值
diff = time2 - time1

# 输出时间差
print("时间差: ", diff)
print("相差的天数: ", diff.days)
print("相差的秒数: ", diff.total_seconds())
