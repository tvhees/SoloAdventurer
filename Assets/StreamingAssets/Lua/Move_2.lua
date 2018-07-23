function describe()
  unity.Print("Script: Move_2. Adds 2 move to player.");
end

function execute(args)
  args.player:AddMovement(2);
  args.player:PlayCard(args.card);
end