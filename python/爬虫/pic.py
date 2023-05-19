import os
import requests
from bs4 import BeautifulSoup
from urllib.parse import urljoin

# 创建保存图片的文件夹
folder_name = 'C:/Users/xiaojiang/Desktop/配置搜索'
if not os.path.exists(folder_name):
    os.mkdir(folder_name)

# 请求网页并解析HTML
url = 'https://pic.netbian.com/4kfengjing/'
response = requests.get(url)
soup = BeautifulSoup(response.content, 'html.parser')

# 获取所有图片的链接，将相对链接转换为绝对链接
links = []
for img in soup.find_all('img'):
    if 'src' in img.attrs:
        link = img['src']
        if link.startswith('//'):
            link = 'http:' + link
        else:
            link = urljoin(url, link)
        links.append(link)

# 下载图片并保存到文件夹
for i, link in enumerate(links[:100]):
    response = requests.get(link)
    file_path = os.path.join(folder_name, f'{i+1}.jpg')
    with open(file_path, 'wb') as f:
        f.write(response.content)
