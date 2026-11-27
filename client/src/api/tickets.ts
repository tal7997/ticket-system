import type { CreateTicketRequest, Ticket, TicketStatus } from "../types";

const API_URL = "https://localhost:7293/api/tickets";

async function handleResponse<T>(response:Response): Promise<T> {
    if (!response.ok)
        throw new Error(`Server error: ${response.status}`);

    return response.json();
}

export async function getTickets(status?: TicketStatus): Promise<Ticket[]> {
    const url = status ? `${API_URL}?status=${status}` : API_URL;
    const response = await fetch(url);

    return handleResponse<Ticket[]>(response);
}

export async function createTicket(ticket: CreateTicketRequest): Promise<Ticket> {
    const response = await fetch(API_URL, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(ticket),
    });

    return handleResponse<Ticket>(response);
}

export async function updateTicketStatus(id: number, status: TicketStatus): Promise<Ticket> {
    const response = await fetch(`${API_URL}/${id}/status`, {
        method: "PATCH",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ status }),
    });

    return handleResponse<Ticket>(response);
}

export async function deleteTicket(id: number): Promise<void> {
    const response = await fetch(`${API_URL}/${id}`, {method: "DELETE"});
    
    if (!response.ok)
        throw new Error(`Server error: ${response.status}`);
}
