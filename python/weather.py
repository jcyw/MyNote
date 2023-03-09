import requests

# 修改为你自己的 AppKey 和 AppSecret
appkey = "SE93ZDzqOrJe-TBfj"
appsecret = "your_appsecret"

url = "https://api.seniverse.com/v3/weather/now.json?key={}&location=chengdu&language=zh-Hans&unit=c".format(appkey)

res = requests.get(url)
print(res.content.decode('utf-8'))  # 打印结果

# 获取经纬度
# posUrl = "https://ipinfo.io/json"
# res = requests.get(posUrl)
# print(res.content)  # 打印结果
