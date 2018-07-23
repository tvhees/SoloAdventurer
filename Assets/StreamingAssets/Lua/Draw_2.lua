function describe()
  unity.Print("Script: Draw_2. Draws 2 cards.");
end

function execute(args)
  args.player:DrawCards(2);
  args.player:PlayCard(args.card);
end