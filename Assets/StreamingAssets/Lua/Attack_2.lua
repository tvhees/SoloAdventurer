function describe()
  unity.Print("Script: Attack_2. Adds 2 attack to player.");
end

function execute(args)
  args.player:AddAttack(2);
  args.player:PlayCard(args.card);
end