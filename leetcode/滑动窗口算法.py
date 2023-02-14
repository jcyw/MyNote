# 给你一个字符串 s 、一个字符串 t 。返回 s 中涵盖 t 所有字符的最小子串。如果 s 中不存在涵盖 t 所有字符的子串，则返回空字符串 "" 。

#  
# 注意：

# 对于 t 中重复字符，我们寻找的子字符串中该字符数量必须不少于 t 中该字符数量。
# 如果 s 中存在这样的子串，我们保证它是唯一的答案。
#  
# 示例 1：
# 输入：s = "ADOBECODEBANC", t = "ABC"
# 输出："BANC"
# 解释：最小覆盖子串 "BANC" 包含来自字符串 t 的 'A'、'B' 和 'C'。
# 示例 2：
# 输入：s = "a", t = "a"
# 输出："a"
# 解释：整个字符串 s 是最小覆盖子串。
# 示例 3:
# 输入: s = "a", t = "aa"
# 输出: ""
# 解释: t 中两个字符 'a' 均应包含在 s 的子串中，
# 因此没有符合条件的子字符串，返回空字符串。

# 来源：力扣（LeetCode）
# 链接：https://leetcode.cn/problems/minimum-window-substring
# 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

# 最小覆盖子串


s = "ADOBECODEBANC"
t = "ABC"
right = 0
left = 0
tempStr = ""
curMinStr = ""
dict = {}

# 初始化计数字典
def Initdc(t):
    for v in t:
        dict[v] = 0

def GetminStr(s, right , left , tempStr , curMinStr, dict):
    while right < len(s):
        tempStr = tempStr + s[right]
        if IsFit(tempStr,dict):
            curMinStr = tempStr
            # 加左边
            while True:
                left = left + 1
                if left >= right:
                    left = right
                    break
                tempStr = tempStr[1:]
                if IsFit(tempStr, dict):
                    if len(tempStr) < len(curMinStr):
                        curMinStr = tempStr
                else:
                    break
        right = right + 1

    return curMinStr


# 判断字符串是否包含目标字符串
def IsFit(dcStr = "", dict = {}):
    for st in dcStr:
        if st in dict:
            dict[st] = dict[st] + 1
    dcLen = 0
    for v in dict.values():
        dcLen = dcLen + (v > 0 and 1 or 0)
    for k in dict.keys():
        dict[k] = 0
    return dcLen == len(dict)

Initdc(t)

print(GetminStr(s, right , left , tempStr , curMinStr, dict))