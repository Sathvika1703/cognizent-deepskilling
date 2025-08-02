import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: "Mr. Jack", score: 90 },
    { name: "Mr. John", score: 70 },
    { name: "Mr. Ashwin", score: 78 },
    { name: "Mr. Dhoni", score: 61 },
    { name: "Mr. Kohli", score: 60 },
    { name: "Mr. Rahul", score: 100 },
    { name: "Mr. Hardik", score: 55 },
    { name: "Mr. Pandya", score: 64 },
    { name: "Mr. Jadeja", score: 45 },
    { name: "Mr. Raina", score: 76 },
    { name: "Mr. Rohit", score: 50 }
  ];

  const lowScorers = players.filter(p => p.score < 70);

  return (
    <div>
      <h2>List of Players</h2>
      <ul>
        {players.map((p, index) => (
          <li key={index}>{p.name} {p.score}</li>
        ))}
      </ul>

      <h2>List of Players having Scores Less than 70</h2>
      <ul>
        {lowScorers.map((p, index) => (
          <li key={index}>{p.name} {p.score}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;
