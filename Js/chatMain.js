// const axios = require('axios');

// // 设置 OpenAI API 密钥
// const api_key = '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';

// try {
//   const prompt = "1+1=?";

//   const params = {
//     model: 'text-davinci-003',
//     prompt: prompt,
//     max_tokens: 500,
//     temperature: 0.9,
//     top_p: 1,
//     frequency_penalty: 0.0,
//     presence_penalty: 0.6,
//     stop: [" 人类:", " AI:"]
//   };

//   axios.post('https://api.openai.com/v1/engines/davinci-codex/completions', params, {
//     headers: {
//       'Authorization': `Bearer ${api_key}`,
//       'Content-Type': 'application/json'
//     }
//   })
//     .then(response => {
//       const generatedText = response.data.choices[0].text;
//       console.log("生成的文本:", generatedText);
//     })
//     .catch(error => {
//       console.error("错误:", error.response.data);
//     });
// } catch (error) {
//   console.error("错误:", error);
// }

const { Configuration, OpenAIApi } = require("openai");

const configuration = new Configuration({
  apiKey: "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",
});
const openai = new OpenAIApi(configuration);

async function generateText() {
  try {
    const response = await openai.createCompletion({
      model: "text-davinci-002",
      prompt: "1+1 = ?",
      temperature: 0.9,
      max_tokens: 150,
      top_p: 1,
      frequency_penalty: 0.0,
      presence_penalty: 0.6,
      stop: [" Human:", " AI:"],
    });

    console.log(response.data.choices[0].text);
  } catch (error) {
    console.error("Error:", error);
  }
}

generateText();

