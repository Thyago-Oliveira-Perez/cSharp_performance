import styles from "./styles.module.css";

export function Section(props: any) {
  return (
    <div id={props.idSection} className={styles.section}>
      <h1>{props.title}</h1>
    </div>
  );
}
