import openai
import os

# 从环境变量中读取 API 密钥
# api_key = os.getenv("OPENAI_API_KEY")
# openai.api_key = api_key
# 设置 API 密钥
openai.api_key = "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"

try:
    response = openai.Completion.create(
        model="text-davinci-003",
        prompt="The following is a conversation with an AI assistant. The assistant is helpful, creative, clever, and very friendly.\n\nHuman: Hello, who are you?\nAI: I am an AI created by OpenAI. How can I help you today?\nHuman: I'd like to cancel my subscription.\nAI:",
        temperature=0.9,
        max_tokens=500,
        top_p=1,
        frequency_penalty=0.0,
        presence_penalty=0.6,
        stop=[" Human:", " AI:"]
    )

    if response.choices and response.choices[0].text:  # 检查响应结果中是否有文本
        generated_text = response.choices[0].text
        print("Response Text:", generated_text)
    else:
        print("No response text found.")
except Exception as e:
    print("Error:", e)


# openai.api_base = "https://api.openai.com"

# import requests

# from requests.adapters import HTTPAdapter
# from requests.packages.urllib3.util.retry import Retry

# retry_strategy = Retry(
#     total=3,
#     status_forcelist=[429, 500, 502, 503, 504],
#     allowed_methods=["GET", "POST"],
#     backoff_factor=1,
# )
# adapter = HTTPAdapter(max_retries=retry_strategy)
# http = requests.Session()
# http.mount("https://", adapter)
# http.mount("http://", adapter)

# def generate_text(prompt):
#     completions = openai.Completion.create(
#         engine="text-davinci-002",
#         prompt=prompt,
#         max_tokens=1024,
#         n=1,
#         stop=None,
#         temperature=0.7,
#     )
#     message = completions.choices[0].text
#     return message

# generate_text("The following is a conversation with an AI assistant")
