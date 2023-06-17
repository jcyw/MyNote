import turtle

# 设置窗口大小和背景颜色
turtle.setup(600, 600)
turtle.bgcolor('white')

# 绘制红色心形
heart = turtle.Turtle()
heart.hideturtle()
heart.speed(0)
heart.pencolor('#e74c3c')
heart.fillcolor('#f9a26c')
heart.begin_fill()
heart.left(45)
heart.forward(150)
for i in range(2):
    heart.circle(60, 180)
    heart.left(90)
    heart.circle(60, 180)
heart.forward(150)
heart.end_fill()

# 绘制跳动效果
while True:
    for radius in range(1, 15):
        # 心形变化
        heart.shapesize(radius / 10)
        # 定义心形跳动速度
        turtle.delay(20)
        # 将心形移到窗口中央
        heart.penup()
        heart.goto(0, 0)
        heart.pendown()

# 隐藏画笔，并保持窗口不关闭
heart.hideturtle()
turtle.done()
