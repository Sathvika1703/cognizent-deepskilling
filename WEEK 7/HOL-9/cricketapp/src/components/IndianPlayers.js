import React from 'react';

const IndianPlayers = () => {
  const team = ["Mr. First Player", "Mr. Second Player", "Mr. Third Player", "Mr. Fourth Player", "Mr. Fifth Player", "Mr. Sixth Player"];

  const [first, second, third, fourth, fifth, sixth] = team;

  const oddPlayers = [first, third, fifth];
  const evenPlayers = [second, fourth, sixth];

  const T20players = ["Mr. First Player", "Mr. Second Player", "Mr. Third Player"];
  const RanjiTrophy = ["Mr. Fourth Player", "Mr. Fifth Player", "Mr. Sixth Player"];

  const merged = [...T20players, ...RanjiTrophy];

  return (
    <div>
      <h2>Odd Players</h2>
      <ul>
        <li>First - {oddPlayers[0]}</li>
        <li>Third - {oddPlayers[1]}</li>
        <li>Fifth - {oddPlayers[2]}</li>
      </ul>

      <h2>Even Players</h2>
      <ul>
        <li>Second - {evenPlayers[0]}</li>
        <li>Fourth - {evenPlayers[1]}</li>
        <li>Sixth - {evenPlayers[2]}</li>
      </ul>

      <h2>List of Indian Players Merged:</h2>
      <ul>
        {merged.map((p, index) => (
          <li key={index}>{p}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;
