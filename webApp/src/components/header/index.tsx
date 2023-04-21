import styles from "./styles.module.css";

export function Header() {
  const handleClick = (e: any) => {
    e.preventDefault();

    const targetId = e.currentTarget.getAttribute("href");
    const targetElement = document.querySelector(targetId);

    if (targetElement) {
      targetElement.scrollIntoView({ behavior: "smooth" });
    } else {
      console.error(`No element found with ID ${targetId}`);
    }
  };

  return (
    <header className={styles.header}>
      <ul className={styles.actions}>
        <li>
          <a href="#section1" onClick={handleClick}>
            Home
          </a>
        </li>
        <li>
          <a href="#section2" onClick={handleClick}>
            Get Started
          </a>
        </li>
        <li>
          <a href="#section3" onClick={handleClick}>
            About
          </a>
        </li>
      </ul>
    </header>
  );
}
