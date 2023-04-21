import { Section } from "./components/section";
import styles from "./styles.module.css";

export function HomePage() {
  return (
    <>
      <div className={styles.container}>
        <Section idSection="section1" title="hello1" />
        <Section idSection="section2" title="hello2" />
        <Section idSection="section3" title="hello3" />
      </div>
    </>
  );
}
