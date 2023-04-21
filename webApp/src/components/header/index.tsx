import styles from "./styles.module.css";

export function Header() {
  return (
    <header className={styles.header}>
      <ul className={styles.actions}>
        <li>Home</li>
        <li>Get Started</li>
        <li>About</li>
      </ul>
    </header>
  );
}
