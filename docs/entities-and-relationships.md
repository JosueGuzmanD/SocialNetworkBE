## **Entities and Relationships**

### **1. Player**

#### **Description**
The **Player** entity represents football players in the system, capturing essential attributes like name, email, and performance stats. Players interact with other entities like `Friendship`, `Team`, and `Match`.

#### **Properties**
- `Name`: Player's name.
- `Email`: Email address.
- `AvatarUrl`: URL for player’s avatar.
- `Positions`: List of preferred positions (e.g., defender, forward).
- `Stats`: Player stats, encapsulated in the **`UserStats`** Value Object.
- `Friendships`: Player’s friendship relationships.
- `GroupMemberships`: Teams/groups the player belongs to.
- `Notifications`: Notifications related to the player.

#### **Relationships**
- **Friendship**: Friendships with other players.
- **Team**: Players can belong to multiple teams.
- **Match**: Participates in one or more matches.

---

### **2. Match**

#### **Description**
A **Match** is a football game that a player creates. It contains all essential match details, including the field, players, match statistics, and duration.

#### **Properties**
- `StartTime`: Match start time.
- `EndTime`: Match end time.
- `MatchDuration`: Duration of the match, encapsulated in a Value Object.
- `FootballField`: Field where the match is held.
- `Players`: List of players in the match.
- `CreatedBy`: Player who organized the match.
- `Stats`: Match statistics, encapsulated in the **`MatchStats`** aggregate.

#### **Relationships**
- **FootballField**: Field associated with the match.
- **Player**: List of participating players.
- **MatchStats**: Match statistics (goals, top players).

---

### **3. Team**

#### **Description**
A **Team** represents a group of players that can join matches. Teams can be either recurring or ad-hoc for single matches.

#### **Properties**
- `Name`: Team name.
- `Players`: List of players in the team.
- `Stats`: Team statistics, encapsulated in the **`TeamStats`** Value Object.
- `IsRecurrent`: Indicates if the team is a regular or a one-time team.

#### **Relationships**
- **Player**: Players in the team.
- **Match**: Matches the team has played in.

---

### **4. FootballField**

#### **Description**
A **FootballField** represents a football field where matches are held.

#### **Properties**
- `Name`: Field name.
- `Location`: Field location.
- `Address`: Field address, encapsulated in the **`Address`** Value Object.
- `FieldType`: Turf type (natural or artificial).
- `FieldCapacity`: Field capacity (5v5, 7v7, 11v11).
- `Bookings`: List of field reservations.

#### **Relationships**
- **Booking**: Reservations linked to this field.
- **Match**: Matches played on this field.

---

### **5. Booking**

#### **Description**
**Booking** represents a reservation for a football field for a specific match. A player can book a field for future matches.

#### **Properties**
- `Field`: Reserved field.
- `Match`: Match linked to the booking.
- `ReservationDate`: Reservation date.
- `TotalPrice`: Total cost of the booking.
- `ReservedBy`: Player who made the reservation.
- `Status`: Reservation status (pending, confirmed, canceled).

#### **Relationships**
- **FootballField**: Reserved field.
- **Match**: Match linked to the booking.
- **Player**: Player who made the booking.

---

### **6. Post**

#### **Description**
A **Post** is a publication used to announce a match or share results. It serves as a social interaction point on the platform.

#### **Properties**
- `Content`: Content of the post.
- `CreatedBy`: Player who created the post.
- `PostType`: Type of post (match announcement or result).
- `MatchId`: Match related to the post (if applicable).

#### **Relationships**
- **Match**: Match-related post.
- **Player**: Player who created the post.
- **Comment**: Comments associated with the post.

---

### **7. Friendship**

#### **Description**
The **Friendship** entity represents a friendship relationship between two players on the platform.

#### **Properties**
- `User1Id`: First player in the friendship.
- `User2Id`: Second player in the friendship.
- `Status`: Friendship status (pending, accepted, rejected).

#### **Relationships**
- **Player**: The two players involved in the friendship.

---

### **8. MatchStats**

#### **Description**
**MatchStats** is an aggregate that encapsulates match statistics, such as goals scored and standout players.

#### **Properties**
- `GoalsTeamA`: Goals scored by Team A.
- `GoalsTeamB`: Goals scored by Team B.
- `ScorersTeamA`: Players who scored for Team A.
- `ScorersTeamB`: Players who scored for Team B.

#### **Relationships**
- **Player**: Players who scored goals.
