import { useCallback, useEffect, useState } from "react";
import { getTickets } from "./api/tickets";
import type { Ticket, TicketStatus } from "./types";
import "./App.css";

function App() {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [statusFilter, setStatusFilter] = useState<TicketStatus | "">("");

  const loadTickets = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await getTickets(statusFilter || undefined);
      setTickets(data);
    } catch {
      setError("לא הצלחנו לטעון את הקריאות. וודא שהשרת פועל ונסה שוב.");
    } finally {
      setLoading(false);
    }
  }, [statusFilter]);

  useEffect(() => {
    // Fetching data from the server is a legitimate external sync
    // eslint-disable-next-line react-hooks/set-state-in-effect
    loadTickets();
  }, [loadTickets]);

  return (
    <div className="app">
      <h1>מערכת קריאות שירות</h1>
      {loading && <p>טוען קריאות...</p>}

      {error && (
        <div className="error">
          <p>{error}</p>
          <button onClick={loadTickets}>נסה שוב</button>
        </div>
      )}

      {!loading && !error && tickets.length === 0 && <p>אין קריאות לתצוגה</p>}
      {!loading && !error && tickets.length > 0 && (
        <ul>
          {tickets.map((t) => (
            <li key={t.id}>
              {t.title} | {t.status} |{" "}
              {new Date(t.createdAt).toLocaleString("he-IL")}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;
