# 给你一个 m * n 的矩阵，矩阵中的元素不是 0 就是 1，请你统计并返回其中完全由 1 组成的 正方形 子矩阵的个数。
# 示例 1：

# 输入：matrix =
# [
#   [0,1,1,1],
#   [1,1,1,1],
#   [0,1,1,1]
# ]
# 输出：15
# 解释： 
# 边长为 1 的正方形有 10 个。
# 边长为 2 的正方形有 4 个。
# 边长为 3 的正方形有 1 个。
# 正方形的总数 = 10 + 4 + 1 = 15.

matrix = [
  [0,1,1,1],
  [1,1,1,1],
  [0,1,1,1]
]

def countSquares(matrix):
        if len(matrix) == 0:
            return sum(matrix)
        rows, cols = len(matrix), len(matrix[0])
        dp = [[0]*cols for _ in range(rows)]
        print(dp)
        ans = 0
        for i in range(rows):
            for j in range(cols):
                # print(i , j)
                if matrix[i][j] == 0:
                    continue
                if i == 0 or j == 0:
                    dp[i][j] = matrix[i][j]
                else:
                    dp[i][j] = min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1])+1
                ans += dp[i][j]
        print(ans)
        return ans

countSquares(matrix)