import { Route, Routes } from "react-router-dom";
import { HomePage } from "../pages/home";
import { Header } from "../components/header";
import { Footer } from "../components/footer";
import styles from "./styles.module.css";

export default function RouterConfig() {
  return (
    <div className={styles.routes}>
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
      </Routes>
      <Footer />
    </div>
  );
}
