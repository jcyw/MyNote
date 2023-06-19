import openai
import os
openai.api_key = "自己的key"

def askGPT(prompt):
    if not prompt:
        return
    try:
        response = openai.Completion.create(
            # model="text-davinci-003",#gpt3
            model="text-davinci-002",#gpt3.5
            prompt=prompt,
            temperature=0.9,
            max_tokens=500,
            top_p=1,
            frequency_penalty=0.0,
            presence_penalty=0.6,
            stop=[" Human:", " AI:"]
        )

        if response.choices and response.choices[0].text:  # 检查响应结果中是否有文本
            generated_text = response.choices[0].text
            print("## 结果：\n\n" + generated_text)
        else:
            print("No response text found.")
    except Exception as e:
        print("Error:", e)

