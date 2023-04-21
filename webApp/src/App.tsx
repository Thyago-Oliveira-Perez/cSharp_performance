import { BrowserRouter } from "react-router-dom";
import RouterConfig from "./routes/router-config";
import { Header } from "./components/header";
import { Footer } from "./components/footer";
function App() {
  return (
    <BrowserRouter>
      <Header />
      <RouterConfig />
      <Footer />
    </BrowserRouter>
  );
}

export default App;
