import ChatBot from "react-simple-chatbot";
import { ThemeProvider } from "styled-components";
function ChatBotView() {
  const steps = [
    {
      id: "0",
      message: "Hey, hope you are doing well!",
      trigger: "1",
    },
    {
      id: "1",
      options: [
        { value: 1, label: "Learn more about shopping local", trigger: "2" },
        { value: 2, label: "Local food markets", trigger: "3" },
      ],
    },
    {
      id: "2",
      component: (
        <div>
          <a href={`https://www.tonyrobbins.com/business/why-shop-local/`}>
            Click to learn more about shopping local
          </a>
        </div>
      ),
      asMessage: true,
      trigger: "4",
    },
    {
      id: "3",
      component: (
        <div>
          <a href={`https://www.google.com/search?q=food+market+in+`}>
            Click to view farmers markets near you
          </a>
        </div>
      ),
      asMessage: true,
      trigger: "4",
    },
    {
      id: "4",
      options: [{ value: 1, label: "Explore more", trigger: "1" }],
    },
  ];
  const theme = {
    background: "#18bca4",
    headerBgColor: "#ffff",
    headerFontSize: "20px",
    botBubbleColor: "#0F3789",
    headerFontColor: "black",
    botFontColor: "white",
    userBubbleColor: "#FF5733",
    userFontColor: "white",
  };

  const config = {
    floating: true,
  };

  return (
    <div className="ChatBotView">
      <ThemeProvider theme={theme}>
        <ChatBot headerTitle="GeekBot" steps={steps} {...config} />
      </ThemeProvider>
    </div>
  );
}

export default ChatBotView;
