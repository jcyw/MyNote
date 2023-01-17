-- 给你 二维 平面上两个 由直线构成且边与坐标轴平行/垂直 的矩形，请你计算并返回两个矩形覆盖的总面积。

-- 每个矩形由其 左下 顶点和 右上 顶点坐标表示：

-- 第一个矩形由其左下顶点 (ax1, ay1) 和右上顶点 (ax2, ay2) 定义。
-- 第二个矩形由其左下顶点 (bx1, by1) 和右上顶点 (bx2, by2) 定义。

-- 来源：力扣（LeetCode）
-- 链接：https://leetcode.cn/problems/rectangle-area
-- 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

function GetComArea(ax1 , ay1 , ax2 , ay2 , bx1 , by1 , bx2 , by2)
    --- a矩形对角
    local a = {
        x = ax1,
        y = ay1
    }
    local b = {
        x = ax2,
        y = ay2
    }
    --- b矩形对角
    local c = {
        x = bx1,
        y = by1
    }
    local d = {
        x = bx2,
        y = by2
    }
    local area1 = math.abs(a.x - b.x) * math.abs(a.y - b.y)
    local area2 = math.abs(c.x - d.x) * math.abs(c.y - d.y)
    ---- 求高边
    local h1 = a.y > b.y and a or b
    local h2 = c.y > d.y and c or d
    ---- 求底边
    local dd1 = a.y < b.y and a or b
    local dd2 = c.y < d.y and c or d
    --- 高边取小 ， 底边取大
    ---- 高点
    local xh = h1.x < h2.x and h1.x or h2.x
    local yh = h1.y < h2.y and h1.y or h2.y
    ---- 低点
    local xd = dd1.x > dd2.x and dd1.x or dd2.x
    local yd = dd1.y > dd2.y and dd1.y or dd2.y

    local area = math.abs(xh - xd) * math.abs(yh - yd)
    local ans = area1 + area2 - area
    print(ans)
end