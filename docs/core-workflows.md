## **Core Workflows**

### **1. Match Management**

1. **Create a match**: A player organizes a match using the `POST /api/matches` endpoint.
2. **Invite players**: The match organizer can invite players from their friend list or leave the match open.
3. **Confirm match**: When enough players join, the match is confirmed, and notifications are sent.
4. **Play and finish match**: Participants play, and the organizer records statistics post-match.
5. **Cancel match**: The organizer can cancel if needed.

---

### **2. Booking Management**

1. **Check availability**: Players can search for available fields using `GET /api/fields/availability`.
2. **Reserve a field**: Reserve a field using `POST /api/bookings`.
3. **Cancel booking**: Cancel a booking if the match will not take place.

---

### **3. Post Management**

1. **Create post**: Players can announce matches or post results.
2. **Comment on posts**: Other players can comment on these posts.
3. **React to posts**: Players can "like" or react to posts for social interaction.

---

### **4. Team Management**

1. **Create recurring team**: Players form teams for regular matches.
2. **Join a team**: Players request or are invited to join teams.
3. **View team stats**: Team performance and stats are tracked.
