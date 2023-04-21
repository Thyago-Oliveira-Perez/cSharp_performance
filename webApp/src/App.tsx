import { BrowserRouter } from "react-router-dom";
import RouterConfig from "./routes/router-config";
function App() {
  return (
    <BrowserRouter>
      <RouterConfig />
    </BrowserRouter>
  );
}

export default App;
