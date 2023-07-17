import openai
import os
import asyncio

openai.api_key = "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"

async def askGPT(prompt):
    print(prompt)
    if not prompt or prompt == "请输入文本":
        return "请输入文本"
    try:
        response = await asyncio.wait_for(openai.Completion.create(
            # model="text-davinci-003",#gpt3
            model="text-davinci-002",#gpt3.5
            prompt=prompt,
            temperature=0.9,
            max_tokens=500,
            top_p=1,
            frequency_penalty=0.0,
            presence_penalty=0.6,
            stop=[" Human:", " AI:"]
        ), timeout=10)
        return response.choices[0].text.strip()
    except asyncio.TimeoutError:
        return "请求超时，请重试"
    except Exception as e:
        return f"请求出错：{e}"
