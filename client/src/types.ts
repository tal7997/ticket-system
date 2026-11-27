export type TicketStatus = "Open" | "InProgress" | "Closed";
export type TicketUrgency = "Low" | "Medium" | "High";

export interface Ticket {
    id: number;
    title: string;
    description: string;
    urgency: TicketUrgency;
    status: TicketStatus;
    createdAt: string;
}

export interface CreateTicketRequest {
    title: string;
    description: string;
    urgency: TicketUrgency;
}
