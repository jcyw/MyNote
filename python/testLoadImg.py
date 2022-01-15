import requests
def request_download(file,list_data):
    file_name=file[:-4]
    os.makedirs(f'./img/{file_name}/',exist_ok=True) #创建文件夹
    IMAGE_URL='http://www.supe.com.cn'+list_data[0]
    print(IMAGE_URL)
    header={
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36'

    }
    r = requests.get(IMAGE_URL,headers=header)
    with open(f'./img/{file_name}/{list_data[1]}.jpg', 'wb') as f:
        f.write(r.content)

import os
if __name__ == '__main__':

    file_names=os.listdir('./img')
    print(file_names)
    for file_each in file_names:
        print(file_each)
        if file_each.endswith('.csv'):
            file=open(f'./img/{file_each}',encoding='utf-8')
            links=file.readlines()
            for line in links:
                print(line.split(','))
                data=line.split(',')
                request_download(file_each,data)