import requests

url = 'https://docs.unity3d.com/Manual/index.html'
response = requests.get(url)
response.encoding = 'utf-8'
with open('unity_docs.txt', 'w', encoding='utf-8') as f:
    f.write(response.text)
