import { Link } from "react-router-dom";
import styles from "./Layout.module.css";

export default function Layout({
    children,
}:{
    children: React.ReactNode;
}) {
    return (
        <div className={styles.container}>
            <header className={styles.header}>
                <h2>Order Management</h2>
                <nav className={styles.nav}>
                    <Link to="/" className={styles.link}>
                        Pedidos
                    </Link>
                    {" | "}
                    <Link to="/create" className={styles.link}>
                        Novo Pedido
                    </Link>
                </nav>
            </header>
            <main>
                {children}
            </main>
        </div>
    );
}